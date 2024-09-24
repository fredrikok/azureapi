# Use the official Maven image as a parent image
FROM maven:3.9.6-eclipse-temurin-17 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the pom.xml file
COPY pom.xml .

# Copy the project source
COPY src ./src

# Package the application
RUN mvn clean package -DskipTests

# Use OpenJDK for the runtime image
FROM eclipse-temurin:17-jre-alpine

# Set the working directory in the container
WORKDIR /app

# Copy the packaged JAR file from the build stage
COPY --from=build /app/target/*.jar app.jar

# Expose the port the app runs on
EXPOSE 80

# Run the JAR file
ENTRYPOINT ["java", "-jar", "/app/app.jar"]
