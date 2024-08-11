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

## Docker containerized project setup + Usage
The project leverages Docker containers to streamline the deployment and management of the Blazor web application and the Supabase backend.

### Setup
<a href="https://www.docker.com/">Docker</a>:Ensure that Docker is installed on your system.
Environment Variables: The project relies on environment variables for configuration. Make sure you have the necessary .env file - located in the root directory of the project.

### Build, start, stop containers
Navigate to '''SlottyMedia/docker''', where the Docker-Compose-File is located, to manage all containers:
- '''docker compose up --build -d''': Build the images and start all containers
- '''docker compose up --d''': Start all containers
- '''docker compose down''': Stop all containers and deletes the images.
- '''docker compose stop''': Stop all containers

### Advanced container management
- '''docker ps''': List all running containers
- '''docker ps -a''': List all available containers
- '''docker logs [ContainerID]''': Show logs of specific container
- '''docker exec -it [ContainerID] [Command]''': Execute given linux command in container 

### Accessing the services
- **Blazor Application:** Once the containers are running, you can access the Blazor web application by navigating to '''http://localhost:5234''' in your web browser
- **Supabase Dashboard:** If you need to access the Supabase dashboard, you can do so at '''http://localhost:8000''' from your host machine. 
Use the credentials defined in the '''.env''' file
- **Supabase API:** The Blazor application connects to the Supabase backend via the Kong API gateway. The API gateway is accessible from within the Blazor container using '''http://supabase-kong:8000'''
  
---

Happy coding! 🥳🚀
