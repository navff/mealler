## Docker & Heroku

Ля ля ля
![](https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe)

```
docker build -t mealler .
heroku container:push -a mealler web
heroku container:release -a mealler web
heroku logs
```



## Docker locally
```
docker run -d -p 8080:80 --name mealler1 mealler
```
