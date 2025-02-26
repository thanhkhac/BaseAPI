BaseAPI
|
├── BaseAPI.sln
├── CompanyEmployees
│   ├── appsettings.Development.json
│   ├── appsettings.json
│   ├── ContextFactory
│   │   └── RepositoryContextFactory.cs
│   ├── CsvOutputFormatter.cs
│   ├── Extensions
│   │   ├── ExceptionMiddleWareExtensions.cs
│   │   └── ServiceExtensions.cs
│   ├── internal_logs
│   │   └── internallog.txt
│   ├── MappingProfile.cs
│   ├── Migrations
│   ├── nlog.config
│   ├── Program.cs
│   ├── Properties
│   │   └── launchSettings.json
│   └── Utility
│       └── EmployeeLinks.cs
├── CompanyEmployees.Presentation
│   ├── ActionFilters
│   │   ├── ValidateMediaTypeAttribute.cs
│   │   └── ValidationFilterAttribute.cs
│   ├── AssemblyReference.cs
│   ├── Controllers
│   │   ├── AuthenticationController.cs
│   │   ├── CompaniesController..cs
│   │   ├── CompaniesV2Controller.cs
│   │   ├── EmployeesController.cs
│   │   └── TokenController.cs
│   ├── ModelBinders
│   │   └── ArrayModelBinder.cs
├── Contracts
│   ├── Contracts.csproj
│   ├── ICompanyRepository.cs
│   ├── IDataShaper.cs
│   ├── IEmployeeLinks.cs
│   ├── IEmployeeRepository.cs
│   ├── ILoggerManager.cs
│   ├── IRepositoryBase.cs
│   ├── IRepositoryManager.cs
├── Entities
│   ├── ConfigurationModels
│   │   └── JwtConfiguration.cs
│   ├── Entities.csproj
│   ├── ErrorModel
│   │   └── ErrorDetails.cs
│   ├── Exceptions
│   │   ├── BadRequestException.cs
│   │   ├── CollectionByIdsBadRequestException.cs
│   │   ├── CompanyCollectionBadRequest.cs
│   │   ├── CompanyNotFoundException.cs
│   │   ├── EmployeeNotFoundException.cs
│   │   ├── IdParametersBadRequestException.cs
│   │   ├── MaxAgeRangeBadRequestException.cs
│   │   ├── NotFoundException.cs
│   │   └── RefreshTokenBadRequest.cs
│   ├── LinkModels
│   │   ├── Link.cs
│   │   ├── LinkCollectionWrapper.cs
│   │   ├── LinkParameters.cs
│   │   ├── LinkResourceBase.cs
│   │   └── LinkResponse.cs
│   ├── Models
│   │   ├── Company.cs
│   │   ├── Employee.cs
│   │   ├── Entity.cs
│   │   ├── ShapedEntity.cs
│   │   └── User.cs
├── LoggerService
│   ├── LoggerManager.cs
│   ├── LoggerService.csproj
├── Repository
│   ├── CompanyRepository.cs
│   ├── Configuration
│   │   ├── CompanyConfiguration.cs
│   │   ├── EmployeeConfiguration.cs
│   │   └── RoleConfiguration.cs
│   ├── EmployeeRepository.cs
│   ├── Extensions
│   │   ├── RepositoryEmployeeExtensions.cs
│   │   └── Utility
│   │       └── OrderQueryBuilder.cs
│   ├── RepositoryBase.cs
│   ├── RepositoryContext.cs
│   └── RepositoryManager.cs
├── Service
│   ├── AuthenticationService.cs
│   ├── CompanyService.cs
│   ├── DataShaping
│   │   └── DataShaper.cs
│   ├── EmployeeService.cs
│   └── ServiceManager.cs
├── Service.Contracts
│   ├── IAuthenticationService.cs
│   ├── ICompanyService.cs
│   ├── IEmployeeService.cs
│   ├── IServiceManager.cs
└── Shared
    ├── DataTransferObjects
    │   ├── CompanyDto.cs
    │   ├── CompanyForCreationDto.cs
    │   ├── CompanyForUpdateDto.cs
    │   ├── EmployeeDto.cs
    │   ├── EmployeeForCreationDto.cs
    │   ├── EmployeeForManipulationDto.cs
    │   ├── EmployeeForUpdateDto.cs
    │   ├── TokenDto.cs
    │   ├── UserForAuthenticationDto.cs
    │   └── UserForRegistrationDto.cs
    ├── RequestFeatures
    │   ├── EmployeeParameters.cs
    │   ├── MetaData.cs
    │   ├── PagedList.cs
    │   └── RequestParameters.cs