pipeline{
    agent any
        environment {
        // Define a variable for the application URL
        APP_URL = "http://localhost:5173"
    }
    stages{
        stage('Checkout') {
            steps {
                git branch: 'main', url: 'https://github.com/dtnw/test1.git'
            }
        }
        stage('Build'){
            steps{
                echo "Building Vue.js web app using npm"
                dir("my-project"){
                    bat "npm install"
                    bat "npm run build"
                }
                echo "Vue web app successfully built"
            }
        }
        stage('Start Application') {
            steps {
                echo "Start application"
                script {
                    dir('my-project') {
                        bat 'npm install'
                        // Start the Vue.js application
                        bat 'start /B npm run dev'
                        // Wait for the application to start
                        retry(5) {
                            sleep time: 10, unit: 'SECONDS'
                            bat "curl --fail ${env.APP_URL} || exit 1"
                        }
                    }
                }
            }
            }
        stage('Unit and Integration Tests'){
            steps {
                echo "Begin Selenium Tests"
                dir("test/seleniumtest/seleniumtest"){
                    bat "dotnet run"
                }
                echo "Successfully conducted Selenium Tests"
            }
        }
        stage('Deploy'){
            steps{
                    echo "Deploy the application to 000webhost"
                    ftpPublisher alwaysPublishFromMaster: false,
                    continueOnError: false,
                    failOnError: false,
                    masterNodeName: "main",
                    paramPublish: null,
                    publishers: [[
                        configName: "website",
                        transfers: [[
                            asciiMode: false,
                            cleanRemote: false,
                            excludes: "",
                            flatten: false,
                            makeEmptyDirs: false,
                            noDefaultExcludes: false,
                            patternSeparator: "[, ]+",
                            remoteDirectory: "/public_html",
                            remoteDirectorySDF: false,
                            removePrefix: "my-project/dist",
                            sourceFiles: "my-project/dist/**"
                        ]],
                        usePromotionTimestamp: false,
                        useWorkspaceInPromotion: false,
                        verbose: false
                    ]]
                    echo "Application successfully deployed to sit753-task6.000webhost.com"
                }
        }
    }
}