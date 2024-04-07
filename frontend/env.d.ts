/// <reference types="vite/client" />

declare namespace NodeJS {
    interface ProcessEnv {
        VITE_ENV_API_URL: string;
    }
  }