# Skin Meta – Intelligent Skincare Recommendation System

## Project Overview
Skin Meta is an intelligent skincare application that delivers personalized skincare guidance by combining menstrual cycle awareness, environmental conditions, user-selected products, and AI-powered consultation. The system helps users manage their skincare routine, track skin progress, and resolve skin-related queries through data-driven logic and intelligent backend services.

## Key Features
- Hormonal phase–based skincare recommendations
- Climate and UV-based skincare guidance (temperature, humidity, pollution, UV radiation)
- Product catalog with alerts for selected products
- Personalized day and night skincare routines
- AI-powered skincare consultation using Gemini API
- Daily skin image upload and tracking (Skin Diary)
- Full-size image viewing for detailed inspection
- Phase-specific skincare tips fetched dynamically from a SQL database
- Persistent storage of user’s cycle start date
- Visual UI highlighting of the current hormonal phase
- Interactive dialog for displaying skincare advice

## Core Functionalities

### Product Catalog
- Displays available skincare products
- Allows users to select products based on their skin needs
- Generates alerts and guidance related to the selected products
- Ensures product usage aligns with hormonal phase and skin condition

### Skincare Routine
- Automatically generates **day and night skincare routines**
- Routines are created based on the selected products
- Helps users maintain a structured and consistent skincare regimen
- Adapts recommendations according to hormonal phase insights

### AI Consultation (Gemini API)
- Enables users to ask skincare-related questions
- Uses the **Gemini API on the backend** to process skin concerns
- Provides intelligent, context-aware responses for skincare guidance
- Enhances user support by addressing individual skin queries in real time

### Hormonal Phase & Climate Intelligence
- Calculates the user’s current hormonal phase using selected dates
- Fetches phase-specific skincare behavior, tips, and product recommendations from a SQL database
- Integrates real-time environmental data to dynamically adjust skincare advice

### Skin Diary
- Allows users to upload daily skin images for specific weekdays
- Stores images securely and links them to selected days
- Enables full-size image viewing for better inspection and progress tracking

### User Interface Enhancements
- Highlights the current hormonal phase using distinct colors
- Displays skincare advice in a clean and readable dialog box
- Provides an intuitive and user-friendly experience

## Technologies Used
- C# (.NET)
- SQL Database
- Gemini API (AI-powered consultation)
- Environmental & climate data APIs
- UI components for dialogs, alerts, routines, and image handling

## Project Context
Skin Meta was developed as part of the **Software Engineering course (CS2004)**, following structured user stories, acceptance criteria, and iterative development practices. The project focuses on delivering a real-world, personalized skincare solution using intelligent systems and backend integrations.

## Project Status
All planned features for the current sprint have been successfully implemented.

## License
This project is developed for academic and educational purposes.
