## Prerequisites

- **.NET SDK** 
- **ASP.NET Runtime**
- **Docker** (in order to install **Docker** follow instructions from [official website](https://docs.docker.com/engine/install/) for your specific platform)

### WSL Ubuntu 24.04.1 LTS

Install **.NET SDK** and **ASP.NET** Runtime
```sh
sudo apt update && sudo apt upgrade
sudo add-apt-repository ppa:dotnet/backports
sudo apt-get update && sudo apt-get install -y dotnet-sdk-9.0 aspnetcore-runtime-9.0
```

Install **Docker**
```sh
sudo install -m 0755 -d /etc/apt/keyrings
sudo curl -fsSL https://download.docker.com/linux/ubuntu/gpg -o /etc/apt/keyrings/docker.asc
sudo chmod a+r /etc/apt/keyrings/docker.asc

echo \
  "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.asc] https://download.docker.com/linux/ubuntu \
  $(. /etc/os-release && echo "${UBUNTU_CODENAME:-$VERSION_CODENAME}") stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
sudo apt-get update

sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin

sudo docker run hello-world

```

Add current user to *docker* group 

```sh
sudo usermod -aG docker $USER
```

Enable docker system

```sh
sudo systemctl enable docker
```

and restart your WSL

## Setup

Clone the repository

```sh
git clone https://github.com/xirzo/ispire && cd ispire
```

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

### Single setup command

```
git clone https://github.com/xirzo/ispire && \
    cd ispire && \
    cp backend.env .env && \
    docker compose up --build
```

**or**

```
git clone https://github.com/xirzo/ispire && \
    cd ispire && \
    cp backend.env .env && \
    docker-compose up --build
```

## Deploy on server

Full deployment guide is on my [blog](https://xirzo.ru/post/a8444613-623f-4091-b5c1-403c25c94e7b)
