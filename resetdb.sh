#!/bin/bash

echo "Removing migrations"

rm -r Migrations

echo "Removing database.db"

rm database.db

echo "Creating init migration"

dotnet ef migrations add Init

echo "Updating db"

dotnet ef database update
