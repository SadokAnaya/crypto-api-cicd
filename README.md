# Crypto API – CI/CD with GitHub Actions & AWS

## Overview
A .NET API that exposes two endpoints for encryption and decryption using a Caesar Cipher.
The project demonstrates a complete CI/CD pipeline using Git Flow, GitHub Actions, and AWS Elastic Beanstalk.

## Endpoints
- POST /encrypt?text=abc&shift=3
- POST /decrypt?text=def&shift=3

## Branch Strategy
- feature/* → development work
- develop → integration branch
- main → production

All changes are merged using Pull Requests.

## CI/CD
- CI: Build & unit tests run on push and pull requests (GitHub Actions)
- CD: Automatic deployment to AWS Elastic Beanstalk on merge to main

## Tests
Unit tests implemented using xUnit and executed in CI pipeline.

## Deployment
The API is deployed automatically to AWS Elastic Beanstalk using GitHub Actions.
