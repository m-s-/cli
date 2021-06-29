This is the map of the currently supported commands in cmf-cli

Legend:
- :exclamation: -> needs rework
- :heavy_plus_sign: -> in the backlog
- :link: -> group only, command is a no-op


# Included

- build <- build a package
    - help :link:
        - generateBasedOnTemplates <- generate help index markdown files
        - generateMenuItems <- generate help menu
- bump <- bump package versions
- :exclamation: bumpIoTConfiguration <- this should move to `bump iot configuration`
- :exclamation: bumpIoTCustomization <- this should mode to `bump iot customization`
- ls <- list package tree
- local :link:
    - generateLBOs <- generate LBOs in your local environment
    - getLocalEnvironment <- setup local environment
- pack
- publish
- :heavy_plus_sign: new <- initialize a new repository structure


# Plugins
- ad <- provided by pi-azuredevops-cli (internal, azure devops project management)
- portal <- provided by Portal SDK: interact with DevOps Center 

# Invoking
To invoke nested commands, chain the entire path: e.g. to invoke generateMenuItems, invoke `cmf build help generateMenuItems`

To invoke plugin commands, the arguments need to be separated by a double dash, e.g. `cmf ad -- pipelines list`