# PixelData project

PixelData is WebProject that helps you to manage Image Database

It based on `ASP.NET Core` framework and can be launched in Windows, MacOS or Linux operating systems. 
Also you can run it in the Docker.

## Local deploy

Open command line and do following steps:

- Build app with `dotnet public -c release -o out`
- Start app with `dotnet run out/app.dll`

Also things can be done using Visual Studio on your machine

## Docker deploy

Use Linux Containers!

If you are in system that works with bash, simply run `bash restart.sh`

Otherwise do following steps:

- Open command line
- Check that you are working in the project root
- Build image with command `docker build -t pixeldata:latest .`
- Start container with for example this command: `docker run -dit -p 5000:80 --name pixeldata_app pixeldata`
- Container works under name pixeldata_app and can be accessed at [localhost:5000](http://0.0.0.0:5000/)
