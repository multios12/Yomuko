echo off
rem �t�@�C���폜

dotnet publish yomuko.sln -c release -p:PublishSingleFile=true
mkdir publish
copy .\ArchiveImager\bin\Release\netcoreapp3.1\publish .\publish
copy .\ShelfSync\bin\Release\netcoreapp3.1\publish .\publish
copy .\Yomuko\bin\Release\netcoreapp3.1\publish .\publish
