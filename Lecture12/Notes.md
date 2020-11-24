# Notes

## Azure AD

Follow this: <https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/hosted-with-azure-active-directory>.

### Azure AD Configuration

```yaml
TenantId: b461d90e-0c15-44ec-adc2-51d14f9f5731
Domain: ondfisk.dk
```

### Server API App Registration

```yaml
DisplayName: Lecture12.ServerAPI
ClientId: e4b8ede8-e9a8-4617-8133-a5b3a067673b
AppIdUri: api://e4b8ede8-e9a8-4617-8133-a5b3a067673b
Scope: API.Access
```

#### Client App Registration

```yaml
DisplayName: Lecture12.Client
ClientId: 0221b042-be3d-4ce1-9fad-d386094994f8
```

### Build

```bash
dotnet new blazorwasm -au SingleOrg --api-client-id "e4b8ede8-e9a8-4617-8133-a5b3a067673b" --app-id-uri "e4b8ede8-e9a8-4617-8133-a5b3a067673b" --client-id "0221b042-be3d-4ce1-9fad-d386094994f8" --default-scope "API.Access" --domain "ondfisk.dk" -ho -o "Lecture12" --tenant-id "b461d90e-0c15-44ec-adc2-51d14f9f5731"
```

## Azure AD B2C

Follow this: <https://docs.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/hosted-with-azure-active-directory-b2c>.

### Azure AD Configuration

```yaml
TenantId: 41376db6-7f50-4f7f-bf19-23b826c9b007
Domain: ondfiskb2c.onmicrosoft.com
```

### B2C Server API App Registration

```yaml
DisplayName: Lecture12.ServerAPI
ClientId: 126d05b0-b821-405e-b15e-5e566910d9a3
AppIdUri: https://ondfiskb2c.onmicrosoft.com/126d05b0-b821-405e-b15e-5e566910d9a3
Scope: API.Access
```

#### B2C Client App Registration

```yaml
DisplayName: Lecture12.Client
ClientId: e90ff30b-7180-4eba-b5b7-90ef6a1d51df
SignUpSignInUserFlow: B2C_1_signupsignin
```

### B2C Build

```bash
dotnet new blazorwasm -au IndividualB2C --aad-b2c-instance "https://ondfiskb2c.b2clogin.com/" --api-client-id "126d05b0-b821-405e-b15e-5e566910d9a3" --app-id-uri "https://ondfiskb2c.onmicrosoft.com/126d05b0-b821-405e-b15e-5e566910d9a3" --client-id "e90ff30b-7180-4eba-b5b7-90ef6a1d51df" --default-scope "API.Access" --domain "ondfiskb2c.onmicrosoft.com" -ho -o "Lecture12" -ssp "B2C_1_signupsignin"
```
