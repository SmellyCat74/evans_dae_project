name = input("What is your name? ")
print("Hello,", name)

fruits = []


# Constant for the output file name
FILENAME = "SHOPPING_LIST.txt"

def get_num_fruits():
    """Prompt the user for the number of fruits and return the validated integer."""
    while True:
        try:
            num_fruits = int(input("How many fruits would you like to add? "))
            if num_fruits < 1:
                print("Please enter a positive number.")
            else:
                return num_fruits
        except ValueError:
            print("Invalid input. Please enter a whole number.")
        finally:
            print("Attempt to get number of fruits complete.\n")

def get_fruits(num):
    """Prompt the user to enter fruit names and return the list of fruits."""
    fruits = []
    for index in range(num):
        fruit = input(f'Please enter fruit number {index + 1}: ')
        fruits.append(fruit)
    return fruits

def write_to_file(fruits):
    """Write the list of fruits to a file and handle potential I/O errors."""
    try:
        with open(FILENAME, "w") as file:
            file.write("The list of fruits you entered:\n")
            for i, fruit in enumerate(fruits, start=1):
                file.write(f"{i}. {fruit}\n")
    except IOError:
        print("An error occurred while writing to the file.")
    else:
        print(f"\nThe list has been successfully saved to {FILENAME}")
    finally:
        print("File write attempt complete.\n")

# Main program flow
def main():
    num_fruits = get_num_fruits()
    fruits = get_fruits(num_fruits)
    write_to_file(fruits)

# Run the program
if __name__ == "__main__":
    main()



print('Thank You')













