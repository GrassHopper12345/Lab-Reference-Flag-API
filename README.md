# Lab Reference API

A clean, well-documented REST API for clinical lab value interpretation. Accepts lab panel results and returns standard reference ranges, flags abnormal values, and provides relevant clinical context for common biomarkers. Built as a practical demonstration of .NET 9 REST API architecture with a real-world healthcare data domain.

---

## Features

### Lab Value Interpretation
- Submit individual or batched lab results (test name, value, unit)
- Returns standard reference ranges for each biomarker
- Flags values as Low, Normal, High, or Critical
- Supports age and sex-based reference range adjustments where applicable

### Biomarker Coverage
Covers common panels including:
- **Complete Blood Count (CBC):** WBC, RBC, Hemoglobin, Hematocrit, Platelets, MCV, MCH, MCHC, RDW
- **Comprehensive Metabolic Panel (CMP):** BMP electrolytes, BUN, Creatinine, eGFR, Glucose, AST, ALT, ALP, Total Bilirubin, Total Protein, Albumin
- **Lipid Panel:** Total Cholesterol, LDL, HDL, Triglycerides, non-HDL
- **Thyroid:** TSH, Free T3, Free T4
- **Inflammatory Markers:** CRP, ESR, Ferritin
- **Vitamins & Minerals:** Vitamin D, B12, Folate, Iron, TIBC, Magnesium, Zinc

### Reference Range Management
- Seed database with evidence-based reference ranges
- Admin endpoints to add or update ranges as guidelines evolve
- Supports both conventional (US) and SI units with automatic conversion

### Clinical Context
- Each biomarker includes a brief description of its clinical significance
- Flags indicate actionable ranges (e.g. critical low Hemoglobin, critically elevated Potassium)

---

## Tech Stack

| Technology | Purpose |
|---|---|
| [.NET 9](https://dotnet.microsoft.com/) | Core framework and runtime |
| [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/) | REST API framework with minimal API and controller support |
| [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) | Primary language |
| [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) | ORM for database access and migrations |
| [PostgreSQL](https://www.postgresql.org/) | Relational database for biomarker and reference range data |
| [Swagger / Scalar](https://scalar.com/) | Auto-generated interactive API documentation |
| [FluentValidation](https://fluentvalidation.net/) | Request model validation |
| [xUnit](https://xunit.net/) | Unit and integration testing |
| [Docker](https://www.docker.com/) | Containerized local development and deployment |

---

## API Endpoints

### Lab Results

```
POST   /api/results/interpret         Interpret a single lab result
POST   /api/results/interpret/batch   Interpret a full panel (multiple results)
```

#### Example Request — Single Result

```json
POST /api/results/interpret
{
  "testName": "Hemoglobin",
  "value": 10.2,
  "unit": "g/dL",
  "patientSex": "female",
  "patientAge": 34
}
```

#### Example Response

```json
{
  "testName": "Hemoglobin",
  "value": 10.2,
  "unit": "g/dL",
  "referenceRange": {
    "min": 12.0,
    "max": 16.0,
    "unit": "g/dL"
  },
  "flag": "Low",
  "severity": "Abnormal",
  "clinicalContext": "Hemoglobin carries oxygen in red blood cells. Low values may indicate anemia. Causes include iron deficiency, B12/folate deficiency, chronic disease, or blood loss.",
  "interpretation": "Value is below the reference range for adult females."
}
```

#### Example Request — Batch Panel

```json
POST /api/results/interpret/batch
{
  "patientSex": "male",
  "patientAge": 45,
  "results": [
    { "testName": "WBC", "value": 11.2, "unit": "10^3/uL" },
    { "testName": "Hemoglobin", "value": 14.5, "unit": "g/dL" },
    { "testName": "Creatinine", "value": 1.1, "unit": "mg/dL" },
    { "testName": "ALT", "value": 72, "unit": "U/L" }
  ]
}
```

### Biomarker Reference Data

```
GET    /api/biomarkers                List all supported biomarkers
GET    /api/biomarkers/{name}         Get reference range and context for a specific biomarker
POST   /api/biomarkers               Add a new biomarker entry (admin)
PUT    /api/biomarkers/{id}          Update a biomarker's reference range (admin)
```

---

## Architecture

```
LabReferenceApi/
├── Controllers/            # API endpoint controllers
│   ├── ResultsController.cs
│   └── BiomarkersController.cs
├── Models/                 # Domain models and DTOs
│   ├── LabResult.cs
│   ├── Biomarker.cs
│   └── ReferenceRange.cs
├── Services/               # Business logic
│   ├── InterpretationService.cs
│   └── UnitConversionService.cs
├── Validators/             # FluentValidation validators
├── Data/                   # EF Core DbContext and migrations
│   ├── AppDbContext.cs
│   └── Seed/               # Reference range seed data
└── Tests/
    ├── InterpretationServiceTests.cs
    └── ResultsControllerTests.cs
```

---

## Getting Started

### Prerequisites
- .NET 9 SDK
- Docker (for local PostgreSQL)

### Running Locally

```bash
# Clone the repository
git clone https://github.com/GrassHopper12345/lab-reference-api.git
cd lab-reference-api

# Start PostgreSQL via Docker
docker compose up -d

# Apply EF Core migrations
dotnet ef database update

# Run the API
dotnet run --project LabReferenceApi
```

Swagger UI available at: [http://localhost:5000/swagger](http://localhost:5000/swagger)

### Environment Variables

```json
// appsettings.Development.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=lab_reference;Username=postgres;Password=postgres"
  }
}
```

### Running Tests

```bash
dotnet test
```

---

## Roadmap

- [ ] OAuth2 / API key authentication for admin endpoints
- [ ] Trending support — compare a value against a patient's prior results
- [ ] LOINC code mapping for each biomarker
- [ ] HL7 FHIR-compatible response format option
- [ ] Rate limiting and response caching with Redis

---

## Background

Built by a Medical Laboratory Technician (MLT) with hands-on clinical experience interpreting lab panels. Reference ranges are sourced from standard clinical guidelines (AACC, Mayo Clinic reference intervals). This project demonstrates .NET 9 REST API design, clean architecture, and domain modeling in a healthcare context — a domain where data accuracy and clear validation logic genuinely matter.
