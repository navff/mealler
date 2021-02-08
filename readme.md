## Docker & Heroku

Развёртывание
![](https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe)
![](https://upplabs.com/blog/free-net-core-hosting-on-heroku-through-docker-and-github-guide-for-startups/)

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

## SQLite limitations

https://docs.microsoft.com/en-us/ef/core/providers/sqlite/limitations