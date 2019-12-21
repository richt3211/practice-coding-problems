#
# Ubuntu Dockerfile
#
# https://github.com/dockerfile/ubuntu
#

# Pull base image.
FROM ubuntu:18.04

# Install.
RUN \
  sed -i 's/# \(.*multiverse$\)/\1/g' /etc/apt/sources.list && \
  apt-get update && \
  apt-get -y upgrade && \
  apt-get install -y build-essential && \
  apt-get install -y software-properties-common && \
  apt-get install -y byobu curl git htop man unzip vim wget && \
  rm -rf /var/lib/apt/lists/*
RUN apt-get update && apt-get install -y emacs
RUN apt-get update && apt-get install -y gdb


# Add files.
COPY ./ /root/src


# Define working directory.
WORKDIR /root

# Set environment variables.
ENV HOME /root
