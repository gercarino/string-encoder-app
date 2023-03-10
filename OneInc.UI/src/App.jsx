import React from "react";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";

import { Footer } from "./components/Footer";
import { Encoder } from "./components/Encoder";

function App() {
	console.log({
		BASE_URL: import.meta.env.VITE_API_BASE_URL
	})
	return (
		<Box
			sx={{
				display: "flex",
				flexDirection: "column",
				minHeight: "100vh",
			}}
		>
			<CssBaseline />
			<Container component="main" sx={{ mt: 8, mb: 2 }} maxWidth="sm">
				<Typography variant="h2" component="h1" gutterBottom>
					String Encoder App
				</Typography>
				<Typography variant="h5" component="h2" gutterBottom>
					{"Write some text and click Encode!"}
				</Typography>
				<Encoder />
			</Container>
			<Box
				component="footer"
				sx={{
					py: 3,
					px: 2,
					mt: "auto",
					backgroundColor: (theme) =>
						theme.palette.mode === "light"
							? theme.palette.grey[200]
							: theme.palette.grey[800],
				}}
			>
				<Container maxWidth="sm">
					<Footer />
				</Container>
			</Box>
		</Box>
	);
}

export default App;
