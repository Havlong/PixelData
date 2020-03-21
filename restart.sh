docker container stop pixeldata_app
docker container rm pixeldata_app
docker build -t pixeldata:latest .
docker run -dit -p 5000:80 --name pixeldata_app --restart unless-stopped pixeldata