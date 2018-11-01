#!/bin/bash
cd src
dotnet fable yarn-run build
cd ..
heroku static:deploy
[ -e "public/app.js" ] && rm "public/app.js"
[ -e "public/styles.css" ] && rm "public/styles.css"