#!/bin/bash

# Function to display usage instructions
usage() {
    echo "Usage: $0 <number_of_directories> [prefix]"
    echo "  <number_of_directories>: Number of directories to create"
    echo "  [prefix]: Optional prefix for directory names (default: 'day')"
    exit 1
}

# Check if at least one argument is provided
if [ $# -lt 1 ]; then
    usage
fi

num=$1
prefix=${2:-day}

if ! [[ $num =~ ^[0-9]+$ ]] || [ "$num" -le 0 ]; then
    echo "Error: <number_of_directories> must be a positive integer."
    usage
fi

for ((i = 1; i <= num; i++)); do
    dir_name="${prefix}-${i}"
    mkdir -p "$dir_name" && echo "Created: $dir_name"
done

echo "Successfully created $num_dirs directories."