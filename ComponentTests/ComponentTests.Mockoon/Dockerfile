FROM node:14-alpine

RUN npm install -g @mockoon/cli@2.1.0
COPY ComponentTests.Mockoon/mock-data.json ./mock-data.json

# Do not run as root.
RUN adduser --shell /bin/sh --disabled-password --gecos "" mockoon
RUN chown -R mockoon ./mock-data.json
USER mockoon

EXPOSE 3000

ENTRYPOINT ["mockoon-cli", "start", "--hostname", "0.0.0.0", "--daemon-off", "--data", "mock-data.json", "--container"]

# Usage: docker run -p <host_port>:<container_port> mockoon-test