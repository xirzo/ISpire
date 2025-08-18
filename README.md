## Prerequisites

Install **.NET SDK**, **ASP.NET Runtime** and **Docker**, in order to install **Docker** follow instructions from [official website](https://docs.docker.com/engine/install/) for your specific platform.

### Arch

```sh 
sudo pacman -S dotnet-sdk aspnet-runtime
```

## Setup

Create **secrets**, you may obtain them from your team members

```sh
echo "your_db_password" > db_password.txt
echo "your_db_user" > db_user.txt
echo "your_db_name" > db_name.txt
echo "Host=db;Port=5432;Database=your_db_name;Username=your_db_user;Password=your_db_password" > db_connection_string.txt
```


Start the **docker compose**

```sh
docker-compose --file compose.dev.yaml build

docker-compose --file compose.dev.yaml up -d
```

or (depending on **Docker** version)

```sh
docker compose --file compose.dev.yaml build

docker compose --file compose.dev.yaml up -d
```

