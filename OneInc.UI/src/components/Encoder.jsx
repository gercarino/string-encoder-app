import React, { useState } from 'react';
import Button from '@mui/material/Button';
import LoadingButton from '@mui/lab/LoadingButton';
import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import Stack from '@mui/material/Stack';
import FormControl from '@mui/material/FormControl';

import { useEncoderApi } from '../hooks/useEncoderApi';

/**
 * Germain: The next iteration of this component should be to
 * move to use useReducer hook as we are starting to see multiple useState's
 * which is not a good thing
 *
 * In a real-life scenario, we most likely be using a form builder
 * to ease validations/form states like: Formik or react-hook-form.
 * Reactive Forms in the case of Angular.
 *
 * For now, keeping simple by manually handling the form state
 */

const maxChars = import.meta.env.VITE_MAX_ALLOWED_CHARS;

export const Encoder = () => {
  const [formValue, setFormValue] = useState('');
  const [hasErrors, setHasErrors] = useState(false);
  const [valueToEncode, setValueToEncode] = useState('');
  const { abort, stream, loading, reset, finished } = useEncoderApi(valueToEncode);

  const handleChange = (e) => {
    const value = e.target.value;
    setFormValue(value);
    setHasErrors(() => value.length > maxChars);
  };

  const handleSubmit = (value) => {
    if (hasErrors) {
      return;
    }
    setValueToEncode(() => value);
  };

  const handleReset = () => {
    reset();
    setFormValue('');
    setHasErrors(false);
  };

  return (
    <>
      <Box
        component="form"
        sx={{
          '& .MuiTextField-root': { m: 0, width: '30ch' }
        }}
        noValidate
        autoComplete="off">
        <div>
          <FormControl>
            <TextField
              id="outlined-multiline-flexible"
              label={`String text (max. ${maxChars} chars)`}
              multiline
              error={hasErrors}
              disabled={loading}
              value={formValue}
              onChange={handleChange}
              required
              InputProps={{
                readOnly: loading,
                maxLength: maxChars
              }}
              maxRows={4}
            />
          </FormControl>
        </div>
      </Box>
      <p>{stream}</p>

      <Stack direction="row" spacing={2}>
        <Button
          disabled={hasErrors || !formValue || !loading || finished}
          color="secondary"
          variant="outlined"
          onClick={abort}>
          Cancel
        </Button>
        <Button
          disabled={!formValue || loading}
          color="secondary"
          onClick={handleReset}
          variant="outlined">
          Reset
        </Button>
        <LoadingButton
          disabled={hasErrors || !formValue || finished}
          loading={loading}
          onClick={() => handleSubmit(formValue)}
          variant="outlined">
          Encode
        </LoadingButton>
      </Stack>
    </>
  );
};
