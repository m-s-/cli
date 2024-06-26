#! /usr/bin/env node
"use strict";
const { spawn } = require('child_process');
const envPaths = require('env-paths');
const path = require('path');
const isInstalledGlobally = require('is-installed-globally');
const isPathInside = require('is-path-inside');
const node_modules = require('node_modules-path');
const dbg = require('debug');
const { parsePackageJson } = require('./utils');

const opts = parsePackageJson(__dirname);
const debug = dbg("cmf:debug");

debug("Executing cmf-cli");
let exePath = null;
debug("Determining if cli is installed globally or locally...");
/**
 * we need to check if we are installed globally. 
 * However, this does not cover some cases, depending on how Node was installed, that we need to check manually:
 * - in windows, Node was installed in Program Files but NPM is installed in the user profile (AppData/Roaming)
 */
if (isInstalledGlobally || isPathInside(__dirname, process.env.APPDATA || "dummy") || isPathInside(__dirname, "/usr/local")) {
  debug("cli is installed globally. Getting binary location from user profile...");
  const paths = envPaths("cmf-cli", {suffix: ""});
  exePath = path.join(paths.data, opts.binName);
} else {
  debug("cli is installed locally. Getting binary from node_modules/.bin/cmf-cli...");
  exePath = path.join(node_modules(), ".bin", "cmf-cli", opts.binName);
}
debug("Obtained binary path: " + exePath);

debug(`Spawning cmf-cli from ${exePath} with args ${process.argv.slice(2)} and piping.`);
const child = spawn(exePath, process.argv.slice(2), {stdio: "inherit"});
child.on('close', (code) => {
  debug("Process exited with code " + code);
  process.exitCode = code;
});