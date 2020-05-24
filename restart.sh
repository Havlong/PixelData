docker container stop pixeldata_app
docker container rm pixeldata_app
git pull
docker build -t pixeldata:latest .
docker run -dit -p 5000:80 --name pixeldata_app -v /home/havlong/PixelData:/PixelData/files/ --restart unless-stopped pixeldata
