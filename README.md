## Prerequisites

Install **.NET SDK**, **ASP.NET Runtime** and **Docker**, in order to install **Docker** follow instructions from [official website](https://docs.docker.com/engine/install/) for your specific platform.

### Arch

```sh 
sudo pacman -S dotnet-sdk aspnet-runtime
```

## Setup

Copy **backend.env** file, key inserted in it is for development only. It is not used in production.

>[!NOTE]
> Appliction should work with default backend.env

```sh
cp backend.env .env
```


Start the **docker compose**

```sh
docker-compose build

docker-compose up -d
```

or (depending on **Docker** version)

```sh
docker compose build

docker compose up -d
```

## Deploy on server

Create context to execute **Docker** commands as if you were on VPS.
```sh
docker context create ispire --host=ssh://<username>@<ip>:<port>
```

Use that context.
```sh
docker context use ispire
```

```sh
docker swarm init
```

Deploy to the VPS

```sh
docker stack deploy -c docker-stack.yaml ispire-backend
```
