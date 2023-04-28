# EasyProof

A simple proof of concept ChatGPT integration.  

## What is does?
You provide a paragraph of text and hit the proof button and let ChatGPT proof read and correct it for you.

## SDK

I decided to keep it simple and use an existing C# SDK
https://github.com/betalgo/openai

Install
`Install-Package Betalgo.OpenAI`

## Pre requisites

You need to setup a billing account  
https://platform.openai.com/account/billing/payment-methods

You need to create an API key  
https://platform.openai.com/account/api-keys

Store you API Key securely.  
Note, I store it at the machine level but you could do this at process or user level.
e.g. Windows PC
``` Powershell
[System.Environment]::SetEnvironmentVariable('MY_OPEN_AI_API_KEY', 'your-sdk-api-key-value', 'Machine')
```
