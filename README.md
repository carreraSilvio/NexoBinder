[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](https://github.com/carreraSilvio/NexoBinder/blob/master/LICENSE.md)

# Nexo Binder
Bind your components to fields decoupling UI from logic.

![Imgur](https://i.imgur.com/XcPNTTL.gif)

## Features
* Bind UI components to fields
* When updating values the UI will change automatically
* Easily swap out UI

## Prerequisites
Unity 2018.3 and up

## Install

### Unity 2019.3
1. Open the package manager and point to the rep url

![Imgur](https://i.imgur.com/iYGgINz.png)

### Before Unity 2019.3

#### Option A
1. Open the manifest
2. Add the repo url either via https or ssh

		{
    		"dependencies": {
        		"com.nexobinder": "https://github.com/carreraSilvio/nexobinder.git"
    		}
		}

#### Option B
1. Clone or download the project zip
2. Copy the repo inside your project assets folder

## Usage

### Create Pools
#### Step 1
1. Create a class that will be your View
2. Add the fields that will be exposed

![Imgur](https://i.imgur.com/hDQ6MiV.gif)

#### Step 2
1. Add a binder to your UI component
2. Chose the field it will be bound to

![Imgur](https://i.imgur.com/8Mx76W5.gif)

### Step 3
1. Update the actual data
2. Notify the View
3. See the result on the UI component

![Imgur](https://i.imgur.com/OsvETkZ.png)
