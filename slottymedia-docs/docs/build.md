# Contribute & Build 

---

## How do I contribute as a developer?
<p style="color: red;"><b>READ THIS GUIDE BEFORE CONTRIBUTING</b></p>

Since our project is secured by some pre-commit hooks you have to configure the project correctly before contributing.

This is done as followed:

Clone the project

```git clone https://github.com/SlottySlots/SlottyMedia.git```

Make sure you have installed the following packages globally.

- <a href="https://gitleaks.io/">Gitleaks</a>: Needed for a secret scan pre-commit hook (Make sure it's properly installed by typing gitleaks in your terminal)
- <a href="https://www.npmjs.com/">Node Package Manager</a>: Used to install needed dependencies for pre-commit hooks

After you've cloned the repo make sure to install all needed packages for the hooks via:

```npm i```

Now it should be configured 🚀

---

## How should my commit messages look like?

Our repo follows the <a href="https://www.conventionalcommits.org/en/v1.0.0/">Conventional Commits</a> guidelines.

Allowed commit types are specified as following:

- feat -> Introduces a new features
- fix -> Fixes a bug
- docs -> Updates on the docs
- chore -> Updates a grunt task; no-production code change
- style -> Formatting code style (missing semicolon, prettier execution, etc)
- refactor -> Refactoring existing code e.g. renaming a variable, reworking a function
- ci -> CI Tasks e.g. adding a hook
- test -> Adding new tests, refactoring tests, deleting old tests
- revert -> Revert old commits
- perf -> Performance related refactoring, without functional changes


Happy coding! 🥳🚀
