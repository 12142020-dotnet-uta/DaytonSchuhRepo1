# DaytonSchuhRepo1
## Getting Started
*This is a demo to learn the basics of C# and github.*

- Create a folder where files will be held.
- Change your directory to that folder.
- Open a terminal / command line prompt and use the following commands:
```
git clone https://www.github.com/yourcreatedrepo
git checkout HelloWorldBranch
dotnet new console
```
A new branch was created with the name `HelloWorldBranch` and the `dotnet` command has created the program files necessary to start. Now we can continue to follow the general github flow. (Clone -> Checkout -> Add -> Commit -> Push -> Pull)
- Continuing on the command line prompt:
```
git add .
git commit -m "Add HelloWorld Example"
git push --set-upstream origin HelloWorldBranch
```

This officially pushes the HelloWorldBranch to your repo.

### Notes:

|    Command   |                              Function                           |
|--------------|-----------------------------------------------------------------|
|`git clone`   | copies the repo to your local machine.                          |
|`git checkout`| creates/navigates branches in repo.                             |
|`git add .`   | adds all files in directory.                                    |
|`git commit`  | tells the repo your sure about the changes before you push them.|
|`git push`    | pushes files to branch in remote cloud.                         |
