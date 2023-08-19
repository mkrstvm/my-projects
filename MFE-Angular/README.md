# Steps to follow in MFE world

1. Project Setup - each plugin as differetn project
2. Update Angular configuration file // angular.json - whihc will list the config for each projects
3. Configure Webpack files webpack.config.ts for each project and which will convey its plugin configuration
4. Add a shared library to hold Module Federation Operations and from where it will have logic to load different pplugins as per the route.
5. Dynamically Load Remote Containers

# Module Federation Angular

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 12.1.4.

## Development server

To start this application for a dev server.

- Run npm Install `npm install`
- Build shared lib Run `build:utils`
- Start all mfe Apps Run `start:all`

## View each app

- app1-home `http://localhost:4203/`
- app1-restaurants `http://localhost:4204/`
- app1-orders `http://localhost:4205/`

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/<app-name>` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
