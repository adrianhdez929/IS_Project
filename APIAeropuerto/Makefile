all: up

up:
	docker-compose up --build

down:
	docker-compose down

clean:
	docker-compose down --rmi all

logs:
	docker-compose logs

.PHONY: up down clean logs