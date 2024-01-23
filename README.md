# C# API for a daily journalling app.

Install dependancies and run locally. Uses in memory database currently.

Models:

**User**
- Id
- Email
- Name
- Date stamps

**JournalEntry**
- Id
- Title
- Body
- Supplemental
- Date stamps
- UserID

## Controllers/routes:

**Users**
- GET api/User
- GET api/User/${id}
- POST api/User
- PUT api/User
- DELETE api/User

**JournalEntries**
- GET api/JournalEntry
- GET api/JournalEntry/${id}
- GET api/JournalEntry/User/${userId}
- POST api/JournalEntry
- PUT api/JournalEntry
- DELETE api/JournalEntry