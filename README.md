# string-encoder-app
Frontend and Backend application for string encoding
> DISCLAIMER: This application was implemented with the bare minimum code to cover the requirements of the exercise. Several design and implementation decisions for this app were made based on that fast MVP premise, however, in production/real-life scenarios, these decisions will vary in both frontend and backend implementations (both Architectural and Stack/Tooling).


## Overview
The approach to design an application is always about trade-offs, I like to think in solution designing around pros/downsides instead of what's the best *pattern or principle* to stick to, and even less thinking in the tech stack. 

[Martin Fowler put it in this way](https://www.youtube.com/watch?v=DngAZyWMGR0&t=1s), we should be focusing about *the important stuff*, whatever that is, most of the time those are the things strictly related to what the Domain problem is about and the solution we are trying to provide to our users. Our job as developers is to design solutions that not only solves a real user's problem but that communicate those solutions in a sharable/understandable way.

## Project

This application consists in the following two apps:
- UI : It's a React.js application created with [Vite.js](https://vitejs.dev/), [MaterialUI](https://mui.com/) that contains the bare minimum code to consume a backend API through the native `fetch` JS API. 
- API: NET 6 Application that exposes different endpoints through a REST Api. 

## Install instructions
Docker orchestration support is possible over the application, once `git clone` and having a Docker environment with Linux containers support, it should be enough to run `docker compose up` on the root project directory.

## Local environment URLs:
- Frontend: http://localhost:5173/
- Backend: https://localhost:5001/swagger/index.html

## Tests

Minimum unit tests were created to test the really minimum functionality which is 1) To ensure that a Base64 Encoder is properly working and 2) there is a mechanism to turn that string into a awaitable collection so that it can be *streamed*. 

In a real-life scenario, Unit Tests are not enough as this are just making sure the overall concrete/implementation details are working properly. Most of the time unit tests take advantage of Mocking libraries to provide an early and quick feedback and catch issues soon.

To complement good testing architecture, we should be doing Component/Integration/Functional testing (a lot of names, depending on the context) as these provides a more *user-like* testing, which means, they target domain/use cases instead of just focusing on isolated pieces of code