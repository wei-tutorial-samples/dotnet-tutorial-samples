# .NET CLI publish to single portable exe

youtube link:  
[![Yes](https://img.youtube.com/vi/xnAA4QHHAes/0.jpg)](https://www.youtube.com/watch?v=xnAA4QHHAes)

dotnet cli:  
```bash
dotnet publish -c Release --self-contained true -r win-x64
dotnet publish -c Release --self-contained true -r win-x64 -p:PublishSingleFile=true 
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true
```