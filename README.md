# Exchanger Notification Service

### 1. Сервис отправки уведомлений (C#)
Сервис отправки уведомлений предназначен для отправки кодов подтверждения на email через SMTP сервер.

#### Зависимости
- **.NET 6 или выше**
- **SMTP-сервер для отправки email**


#### Url Method: POST/api/email/send

Request
```json
//Request body
{
  "recipientEmail": "string",
  "subject": "string"
  "body": "string"
}
```
Response

```json
//Json Result 200 (successful)
{
   "Message" : "Code sent"
  
}

//Json Result 200 (failed)
{
  "status": "failed",
  "message": "err message."
}
```

Все запросы отправлять сюда ```http://svalmazchecks1-001-site1.ntempurl.com```
