import { fileURLToPath, URL } from "url"

import { defineConfig } from "vite"
import vue from "@vitejs/plugin-vue"

import fs from "fs"
import path from "path"

const baseFolder =
  process.env.APPDATA !== undefined && process.env.APPDATA !== ""
    ? `${process.env.APPDATA}/ASP.NET/https`
    : `${process.env.HOME}/.aspnet/https`

const certificateArg = process.argv
  .map((arg) => arg.match(/--name=(?<value>.+)/i))
  .filter(Boolean)[0]
const certificateName = certificateArg
  ? certificateArg.groups.value
  : "DemoDefaultMSVueApi"

if (!certificateName) {
  console.error(
    "Invalid certificate name. Run this script in the context of an npm/yarn script or pass --name=<<app>> explicitly."
  )
  process.exit(-1)
}

const certFilePath = path.join(baseFolder, `${certificateName}.pem`)
const keyFilePath = path.join(baseFolder, `${certificateName}.key`)

console.log("certFilePath: ", certFilePath)
console.log("keyFilePath: ", keyFilePath)

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  server: {
    https: {
      key: fs.readFileSync(keyFilePath),
      cert: fs.readFileSync(certFilePath),
      ca: fs.readFileSync(keyFilePath),
    },
    proxy: {
      "/weatherforecast": {
        target: "https://localhost:5001",
        secure: false,
      },
    },
    port: 5002,
  },
  resolve: {
    alias: {
      "@": fileURLToPath(new URL("./src", import.meta.url)),
    },
  },
})
