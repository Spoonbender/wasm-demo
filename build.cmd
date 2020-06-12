pushd rust
echo Building Rust Code
call build.cmd
popd
pushd node
echo Building Node.js Code
call npm run tsc
popd
echo Building .NET Code
pushd aspnetcore
call dotnet build
popd
echo Done!