#!/bin/bash

echo "1. Removing migrations"

rm -r Migrations

echo "2. Removing database.db"

rm database.db

echo "3. Creating init migration"

dotnet ef migrations add Init

echo "4. Updating db"

dotnet ef database update
