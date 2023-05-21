# CountryBuddy - Backend WebAPI
A RESTful API that serves as a limited wrapper to a [GraphQL API](https://studio.apollographql.com/public/countries/variant/current/home) for providing lists of Continents and the details of their Countries.

## API Specification:
https://petstore.swagger.io/?url=https://raw.githubusercontent.com/Nomi/CountryBuddy/develop/API-Specification.yml

## Prerequisites
- .NET Core SDK [Install .NET Core](https://dotnet.microsoft.com/download) [*Tested on version 7.0.100 (.NET 7, but should also work on .NET 6)*]

## Configuration
The project uses a configuration file named appsettings.json. If you need to make any changes, try checking there to see if the required options are present in it.
The following are non-standard configuration options I have added to the appsettings.json file:
| Option | Description | Possible Values |
|----------|-------------|-----------------|
| `EnableHttpsRedirection` | Toggle for enabling or disabling HTTPS Redirection. Useful for local hosting during development. | true or false [Boolean] |
| `GraphQLURI` | URL of the GraphQL API that is being queried. (Though the URI can be changed, the schema will have to be the same as the current one mentioned above) | Any URI to a conformant GraphQL API [String] |


## Building and running

1. Clone the repository:
   ```console
   git clone https://github.com/Nomi/CountryBuddy.git
   ```
   
2. Navigate to the backend directory:
    ```console
    cd **INSERT-PATH-TO-backend-FOLDER-HERE**
    ```
  
3. Build the project with "Release" configuration:

    ```console
    dotnet publish --configuration Release --output ./publish
    ```
4. Run the backend:
  To run the project, just go to the "publish" folder resulting from the above command and then run the "backend.exe" file (either by double-clicking with the left mouse button or using the terminal).
    ```console
    ./publish/backend.exe
    ```
5. Accessing the backend:
   The API should be accessible at http://localhost:5000. Refer to the specification (mentioned above) for help with usage.
   It is recommended to double-check it by reading the starting output of the program. It should say something like:
    ```output
    info: Microsoft.Hosting.Lifetime[14]                                                                                       
    Now listening on: http://localhost:5000
    ```
