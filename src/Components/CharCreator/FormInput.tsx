import React from "react";

type Props = {
  name: string;
  display: string;
  value: any;
  handler: (e: any, key: string) => void;
  type?: string;
};

function FormInput({
  name,
  display,
  value,
  handler,
  type,
} : Props): JSX.Element {
  return (
    <>
      <label htmlFor={name}>{display}: </label>
      <input
        name={name}
        type={type}
        onChange={(e) => handler(e, name)}
        value={value}
        placeholder={type ? value : `Enter ${name}...`}
      ></input>
    </>
  );
}

export default FormInput;
