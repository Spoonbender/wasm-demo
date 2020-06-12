echo Node.js
pushd Node
call npm run start
popd
echo .NET
pushd aspnetcore
call dotnet run
popd
echo WWW
pushd www
call npm run start
popd