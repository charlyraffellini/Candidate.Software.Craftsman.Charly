[![Build status](https://ci.appveyor.com/api/projects/status/54rpvfu2jtm47oqb?svg=true)](https://ci.appveyor.com/project/CarlosRaffellini/candidate-software-craftsman-charly)
[![codecov](https://codecov.io/gh/charlyraffellini/Candidate.Software.Craftsman.Charly/branch/master/graph/badge.svg)](https://codecov.io/gh/charlyraffellini/Candidate.Software.Craftsman.Charly)


---

# Solution to exercise

The solution is a REPL which understand a small grammar in order to parse and execute lines.

The REPL unrestand the operational commands:
-    posting: \<user name> -> \<message>
-    reading: \<user name>
-    following: \<user name> follows \<another user>
-    wall: \<user name> wall

And an extra creational command:
-    create user: new \<user name>

It is required that to execute an operational command, previously the creational corresponding command should be executed. The OC can not operate over users which not exists.

The model was entirely created following TDD practices.

Example of use:

![https://raw.githubusercontent.com/charlyraffellini/Candidate.Software.Craftsman.Charly/master/2016-06-13%20(1).png](https://raw.githubusercontent.com/charlyraffellini/Candidate.Software.Craftsman.Charly/master/2016-06-13%20(1).png)


### Used Tools:

- Visual Studio 2015
- C#6
- ASP MVC
- Resharper
- XUnit, FluentAssertions
- Windows 10


---


# Excercise

Exercise

Implement a console-based social networking application (similar to Twitter) satisfying the scenarios below.

Features

Posting: Alice can publish messages to a personal timeline
 
> Alice -> I love the weather today

> Bob -> Damn! We lost!

> Bob -> Good game though.
 
Reading: I can view Alice and Bob’s timelines
 
> Alice

I love the weather today (5 minutes ago)

> Bob

Good game though. (1 minute ago)

Damn! We lost! (2 minutes ago)
 
Following: Charlie can subscribe to Alice’s and Bob’s timelines, and view an aggregated list of all subscriptions
 
> Charlie -> I'm in New York today! Anyone want to have a coffee?

> Charlie follows Alice

> Charlie wall

Charlie - I'm in New York today! Anyone want to have a coffee? (2 seconds ago)

Alice - I love the weather today (5 minutes ago)
 
> Charlie follows Bob

> Charlie wall

Charlie - I'm in New York today! Anyone wants to have a coffee? (15 seconds ago)

Bob - Good game though. (1 minute ago)

Bob - Damn! We lost! (2 minutes ago)

Alice - I love the weather today (5 minutes ago)

Details
-         The application must use the console for input and output.
-         Users submit commands to the application. There are four commands. “posting”, “reading”, etc. are not part of the commands; commands always start with the user’s name.
-    posting: <user name> -> <message>
-    reading: <user name>
-    following: <user name> follows <another user>
-    wall: <user name> wall
-         Don't worry about handling any exceptions or invalid commands. Assume that the user will always type the correct commands. Just focus on the sunny day scenarios.
-         Don’t bother making it work over a network or across processes. It can all be done in memory, assuming that users will all use the same terminal.
-         Non-existing users should be created as they post their first message. Application should not start with a pre-defined list of users.
-         Exercise should be done either in Java or C#.
-         Provide instructions on how to run the application.
