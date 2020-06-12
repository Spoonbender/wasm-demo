@echo off

echo build for WASM32
cargo build --target wasm32-unknown-unknown --release

echo Run GC to make the WASM much smaller (like, from 1788KB to 28KB)
wasm-gc target/wasm32-unknown-unknown/release/raffle_core.wasm

echo Generate a textual representation for fun and profit!
wasm2wat target/wasm32-unknown-unknown/release/raffle_core.wasm --enable-multi-value > target/wasm32-unknown-unknown/release/raffle_core.wat

echo generate bindings for nodejs
wasm-bindgen target/wasm32-unknown-unknown/release/deps/raffle_core.wasm --nodejs --out-dir ../node/wasm/

echo generate bindings for JS
wasm-bindgen target/wasm32-unknown-unknown/release/deps/raffle_core.wasm --out-dir ../www/wasm/

echo build for WASI
cargo wasi build --release