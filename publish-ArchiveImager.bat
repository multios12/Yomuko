echo off
rem ƒtƒ@ƒCƒ‹íœ

dotnet publish ArchiveImager\ArchiveImager.csproj -c Release -r win10-x64 -p:PublishSingleFile=true
rem dotnet publish -c Release -r win10-x64 --self-contained true -p:PublishSingleFile=false -p:PublishTrimmed=true
mkdir publish
rm .\publish\*
copy .\ArchiveImager\bin\Release\netcoreapp3.1\publish .\publish
