## Prerequisites

Install **.NET SDK**, **ASP.NET Runtime** and **Docker**, in order to install **Docker** follow instructions from [official website](https://docs.docker.com/engine/install/) for your specific platform.

### Arch

```sh 
    sudo pacman -S dotnet-sdk aspnet-runtime
```

## Setup

Copy **.env** and fill it in

```sh
    cp example.env .env
```

Start the **docker compose**

```sh
    docker-compose build

    docker-compose up -d
```

or (depending on **docker** version)

```sh
    docker compose build

    docker compose up -d
```

## Contributing

Before contributing see [C/CONTRIBUTING.md](./CONTRIBUTING.md)
