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

and run:

```npm run init```

Now it should be configured 🚀

## How to Set Up Supabase
To store our secrets, we use Environemt Variables. To set this up, follow this for the individual operating system.

### Mac
export SUPABASE_URL="supabaseURL"
export SUPABASE_KEY=""supabaseKey"

### Windows
setx SUPABASE_URL "supabaseURL"
setx SUPABASE_KEY "supabaseKey"


You can find the required URL and the anonymous public key in the Supabase dashboard at the following link:
[Supabase API Settings](https://supabase.com/dashboard/project/oxihxgwmffwsuzthwaqo/settings/api)

---

Happy coding! 🥳🚀
