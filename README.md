# SDAWorshipConstructor


---

![Version](https://img.shields.io/badge/version-1.2.2-blue)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)
![.NET](https://img.shields.io/badge/.NET-10.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)

## Overview

This app is one of the modules of the community management system. Free to distribute **(Attribution required)**.
It is designed to be deployed as a **Self-Contained** build.

---

## Project Structure

After building the project, your output folder should look like this:

```

/your-application-folder
│
├── SDAWorshipDraft.exe
├── .config/
│   └── config.json
└── data/
    └── hymns.json

````

---

## Configuration

### 📁 `.config/config.json`

```json
{
  "url": "<your_url>"
}
````

### Parameters

* `url` — endpoint used by the application to fetch remote data.

---

## Data

### 📁 `data/hymns.json`

```json
[
  "hymn1",
  "hymn2"
]
```

---

## Deployment Notes

* Build the project as **Self-Contained**
* Place `.config` and `data` folders next to the `.exe`
* Ensure JSON files are valid
* The application will fail to load data if configuration is missing or incorrect

---

## Versioning

Current version: **1.2.2**

---

## Troubleshooting

### ❌ Application does not load data

Check:

* `config.json` exists
* `url` is a valid absolute URL
* `hymns.json` is valid JSON
* Folder structure matches the expected layout

---
