# wasm-demo

## Setup

- Install the Rust toolchain
    - https://www.rust-lang.org/tools/install
- Install Rust WASM
    - https://rustwasm.github.io/wasm-pack/installer/
- Install Cargo Generate
    - `cargo install cargo-generate`
- Install the wasm-gc tool
    - `cargo install wasm-gc`
- Install the cargo-wasi tool
    - `cargo install cargo-wasi`
- Install the specific version of wasm-bindgen that works with this WasmTime version
    - `cargo install -f wasm-bindgen-cli --vers 0.2.55`
- Add target
    - `rustup target add wasm32-unknown-unknown`
- Recommended: Web Assembly Toolkit (wbat)
    - https://github.com/WebAssembly/wabt/releases
- Recommended VSCode Extesions
    - Rust Analyzer
    - WebAssembly
        - Syntax highlighting in textual representation
        - Can convert Wasm binary representation to textual representation in just a few clicks
