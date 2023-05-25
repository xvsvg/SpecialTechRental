FROM node:latest
WORKDIR /client
COPY . .
RUN npm i
RUN npm run build
CMD ["npm", "start"]