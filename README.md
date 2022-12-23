
## Description

The web portal is used for the management of a person's time through calendar, to-do list, reminders and notes. 

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)

## Installation

1) Install the nuget packages listed in the project's .csproj files
2) Connect the PersonalManagementApp and PersonalManagementApp.API with MySQL Database through the user secrets for the projects
3) Delete the migrations present in the PersonalManagementApp.Infrastructure/Data/Migrations folder
4) Initiate a new migration
5) Install the needed packages for the React frotend via the npm install command in the PersonalManagementApp/ClientApp folder
6) Set for startup projects the PersonalManagementApp and PersonalManagementApp.API
7) Run

## Usage

The portal has two areas - one for the users and one for the admins. The area for users will be opened when the project is run, but the admin area is accessible via the mainProjectUrl/admin URL. The area for users offer calendar, todo list, reminders and notes. Through the admin area user with admin privileges can create users and assign roles to them.
