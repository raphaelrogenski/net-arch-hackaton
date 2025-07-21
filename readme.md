# Net Arch Tech Challenge
## 6NETT | Hackaton - Fase 5 | Grupo 18
`Link: https://youtu.be/1es1G84t-AE`

# 🍔 FastTech Foods — Hackathon 6NETT

> Plataforma moderna de pedidos e atendimento para a rede de fast food **FastTech Foods**, construída com foco em **escalabilidade**, **observabilidade** e **automação**.

---

## 🚀 Tech Stack

| Tecnologia        | Finalidade                                            |
|-------------------|--------------------------------------------------------|
| 🟦 .NET 8         | Desenvolvimento das APIs e serviços (C#)              |
| 🐳 Docker         | Criação de imagens dos microsserviços                 |
| ☸️ Kubernetes     | Orquestração dos containers e infraestrutura           |
| 🐰 RabbitMQ       | Comunicação assíncrona entre serviços                  |
| 📊 Grafana        | Visualização de métricas (via Prometheus)             |
| 📈 Zabbix         | Monitoramento de infraestrutura                       |
| 🛠️ GitHub Actions | CI/CD automatizado (build/deploy das aplicações)     |

---

## 🧩 Arquitetura de Microsserviços

Cada componente é um serviço isolado e responsável por parte do domínio da aplicação, com integração via RabbitMQ:

- `AuthAPI`: Autenticação de funcionários e clientes.
- `MenuAPI`: Gerenciamento do cardápio (CRUD de produtos).
- `OrderAPI`: Recebe pedidos dos clientes e publica eventos.
- `OrderService`: Processa pedidos recebidos e gerencia lógica de negócios.
- `KitchenAPI`: Visualiza e atualiza status dos pedidos em preparo.
- `DLQMonitor`: Serviço que consome mensagens com erro da fila (DLQ) para tratamento.

---

## ⚙️ Como rodar localmente no Kubernetes

### 1. 📦 Build das imagens Docker
```bash
docker build -t local_authapi:latest -f dockerfiles/Dockerfile.AuthApi .
docker build -t local_menuapi:latest -f dockerfiles/Dockerfile.MenuApi .
docker build -t local_orderapi:latest -f dockerfiles/Dockerfile.OrderApi .
docker build -t local_orderservice:latest -f dockerfiles/Dockerfile.OrderService .
docker build -t local_kitchenapi:latest -f dockerfiles/Dockerfile.KitchenApi .
docker build -t local_dlqmonitor:latest -f dockerfiles/Dockerfile.DLQMonitor .
```

### 2. ☸️ Subir os recursos no Kubernetes
```bash
kubectl apply -f k8s/namespace/
kubectl apply -f k8s/base/
kubectl apply -f k8s/deployments-tools/
kubectl apply -f k8s/deployments-apps/
kubectl apply -f k8s/services-tools/
kubectl apply -f k8s/services-apps/
kubectl apply -f k8s/ingress-tools/
kubectl apply -f k8s/ingress-apps/
```
- Certifique-se de estar com o cluster ativo (`minikube`, `kind`, `Docker Desktop`, etc.).
- O namespace padrão utilizado é: `hackaton`.

### 3. ❌ Remover todo o ambiente
- Se quiser limpar o cluster:
```bash
kubectl delete namespace hackaton
```

---

##  📡 Observabilidade e Monitoramento
- Grafana: Métricas como CPU, memória e tempo médio de resposta por API.
- Zabbix: Disponibilidade e saúde de pods, nodes e serviços.
- Prometheus: Coleta de métricas expostas pelas APIs via `/api/metrics`.

## 📎 Extras
- APIs seguem padrão RESTful com versionamento.
- Comunicação entre APIs e serviços é assíncrona (eventos).
- CI/CD automatizado com GitHub Actions (build, push e deploy em cluster).
