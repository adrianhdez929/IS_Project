#!/bin/bash
set -e

echo "Verificando si la base de datos 'Aeropuerto' existe..."
DB_HOST='localhost,1433'
DB_PORT='1433'
DB_USER='sa'
DB_PASS='Aeropuerto.311'
DB_NAME='Aeropuerto_DB'

sqlcmd -S $DB_HOST,$DB_PORT -U $DB_USER -P $DB_PASS -Q "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'$DB_NAME') BEGIN CREATE DATABASE [$DB_NAME]; END;"

echo "Base de datos 'Aeropuerto' verificada (y creada si era necesario). Aplicando migraciones..."

dotnet ef database update

echo "Migraciones aplicadas con éxito."

# Inicia la aplicación
dotnet APIAeropuerto.dll
