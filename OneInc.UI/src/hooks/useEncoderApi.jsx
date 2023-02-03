import { useEffect, useRef, useState } from "react";

let controller = new AbortController();
let signal = controller.signal;
const baseUrl = import.meta.env.VITE_API_BASE_URL;

export const encoderStatus = {
	initial: "initial",
	loading: "loading",
	aborted: "aborted",
	finished: "finished",
};

export const useEncoderApi = (value) => {
	const [stream, setStream] = useState([]);
	const [status, setStatus] = useState(encoderStatus.initial);

	const abort = () => {
		controller.abort();
		setStatus(encoderStatus.aborted);
		initController();
	};

	const reset = () => {
		setStatus(encoderStatus.initial);
		setStream([]);
		initController();
	};

	const initController = () => {
		controller = new AbortController();
		signal = controller.signal;
	};

	const removeSpecialChars = (str) =>
		str
			.split("")
			.filter((char) => !['"', "[", "]", ","].includes(char))
			.join("");

	useEffect(() => {
		if (status === encoderStatus.initial && value?.length > 0) {
			setStatus(encoderStatus.loading);
			fetchData(value, signal, setStream, removeSpecialChars).finally(() => {
				setStatus(encoderStatus.finished);
			});
		}
	}, [value]);

	return {
		abort,
		stream,
		loading: status === encoderStatus.loading,
		finished: status === encoderStatus.finished,
		reset,
		status,
	};
};

const fetchData = (payload, signal, setStream, format) => {
	return fetch(`${baseUrl}/api/encoder/delay`, {
		method: "POST",
		signal: signal,
		headers: {
			"Content-Type": "application/json",
		},
		body: JSON.stringify({ value: payload }),
	}).then(async (response) => {
		const reader = response.body?.getReader();
		if (!reader) {
			throw new Error("Failed to read response");
		}
		const decoder = new TextDecoder();
		while (true) {
			const { done, value } = await reader.read();
			if (done) break;
			if (!value) continue;
			const jsonPart = decoder.decode(value);
			setStream((prev) => [...prev, format(jsonPart)]);
		}
		reader.releaseLock();
	});
};
