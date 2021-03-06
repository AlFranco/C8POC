// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOpcodeProcessor.cs" company="AlFranco">
//   Albert Rodriguez Franco 2013
// </copyright>
// <summary>
//   Defines the IOpcodeProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace C8POC.Interfaces.Domain.Services
{
    using C8POC.Interfaces.Domain.Entities;

    /// <summary>
    /// Interface for opcode processing
    /// </summary>
    public interface IOpcodeProcessor
    {
        /// <summary>
        /// 0nnn - SYS addr
        /// Jump to a machine code routine at nnn.
        /// This instruction is only used on the old computers on which Chip-8 was originally implemented. 
        /// It is ignored by modern interpreters.
        /// </summary>
        void JumpToRoutineAtAdress(IMachineState machineState);

        /// <summary>
        /// 00E0 - CLS
        /// Clear the display.
        /// </summary>
        void ClearScreen(IMachineState machineState);

        /// <summary>
        /// 00EE - RET
        /// Return from a subroutine.
        /// The interpreter sets the program counter to the address at the top of the machineState.Stack, 
        /// then subtracts 1 from the machineState.Stack pointer
        /// </summary>
        void ReturnFromSubRoutine(IMachineState machineState);

        /// <summary>
        /// 1nnn - JP addr
        /// Jump to location nnn.
        /// The interpreter sets the program counter to nnn.
        /// </summary>
        void Jump(IMachineState machineState);

        /// <summary>
        /// 2nnn - CALL addr
        /// Call subroutine at nnn.
        /// The interpreter increments the machineState.Stack pointer, then puts the current PC on the top of the machineState.Stack. 
        /// The PC is then set to nnn.
        /// </summary>
        void CallAtAdress(IMachineState machineState);

        /// <summary>
        /// 3xkk - SE Vx, byte
        /// Skip next instruction if Vx = kk.
        /// The interpreter compares register Vx to kk, and if they are equal, increments the program counter by 2.
        /// </summary>
        void SkipNextInstructionIfRegisterEqualsImmediate(IMachineState machineState);

        /// <summary>
        /// 4xkk - SNE Vx, byte
        /// Skip next instruction if Vx != kk.
        /// The interpreter compares register Vx to kk, and if they are not equal, increments the program counter by 2.
        /// </summary>
        void SkipNextInstructionIfRegisterNotEqualsImmediate(IMachineState machineState);

        /// <summary>
        /// 5xy0 - SE Vx, Vy
        /// Skip next instruction if Vx = Vy.
        /// The interpreter compares register Vx to register Vy, and if they are equal, increments the program counter by 2.
        /// </summary>
        void SkipNextInstructionIfRegisterEqualsRegister(IMachineState machineState);

        /// <summary>
        /// 6xkk - LD Vx, byte
        /// Set Vx = kk.
        /// The interpreter puts the value kk into register Vx.
        /// </summary>
        void LoadValueIntoRegister(IMachineState machineState);

        /// <summary>
        /// 7xkk - ADD Vx, byte
        /// Set Vx = Vx + kk.
        /// Adds the value kk to the value of register Vx, then stores the result in Vx.
        /// </summary>
        void AddValueIntoRegister(IMachineState machineState);

        /// <summary>
        /// 8xy0 - LD Vx, Vy
        /// Set Vx = Vy.
        /// Stores the value of register Vy in register Vx.
        /// </summary>
        void LoadRegisterIntoRegister(IMachineState machineState);

        /// <summary>
        /// 8xy1 - OR Vx, Vy
        /// Set Vx = Vx OR Vy.
        /// Performs a bitwise OR on the values of Vx and Vy, then stores the result in Vx. 
        /// A bitwise OR compares the corrseponding bits from two values, and if either bit is 1, 
        /// then the same bit in the result is also 1. Otherwise, it is 0. 
        /// </summary>
        void OrRegistersIntoRegister(IMachineState machineState);

        /// <summary>
        /// 8xy2 - AND Vx, Vy
        /// Set Vx = Vx AND Vy.
        /// Performs a bitwise AND on the values of Vx and Vy, then stores the result in Vx. 
        /// A bitwise AND compares the corrseponding bits from two values, and if both bits are 1, 
        /// then the same bit in the result is also 1. Otherwise, it is 0.
        /// </summary>
        void AndRegistersIntoRegiter(IMachineState machineState);

        /// <summary>
        /// 8xy3 - XOR Vx, Vy
        /// Set Vx = Vx XOR Vy.
        /// Performs a bitwise exclusive OR on the values of Vx and Vy, then stores the result in Vx. 
        /// An exclusive OR compares the corrseponding bits from two values, and if the bits are not both the same, 
        /// then the corresponding bit in the result is set to 1. Otherwise, it is 0. 
        /// </summary>
        void ExclusiveOrIntoRegister(IMachineState machineState);

        /// <summary>
        /// 8xy4 - ADD Vx, Vy
        /// Set Vx = Vx + Vy, set VF = carry.
        /// The values of Vx and Vy are added together. If the result is greater than 8 bits (i.e., > 255,) VF is set to 1, 
        /// otherwise 0. Only the lowest 8 bits of the result are kept, and stored in Vx.
        /// </summary>
        void AddRegistersIntoRegister(IMachineState machineState);

        /// <summary>
        /// 8xy5 - SUB Vx, Vy
        /// Set Vx = Vx - Vy, set VF = NOT borrow.
        /// If Vx > Vy, then VF is set to 1, otherwise 0. Then Vy is subtracted from Vx, and the results stored in Vx.
        /// </summary>
        void SubstractRegisters(IMachineState machineState);

        /// <summary>
        /// 8xy6 - SHR Vx {, Vy}
        /// Set Vx = Vx SHR 1.
        /// If the least-significant bit of Vx is 1, then VF is set to 1, otherwise 0. Then Vx is divided by 2.
        /// </summary>
        void ShiftRegisterRight(IMachineState machineState);

        /// <summary>
        /// 8xy7 - SUBN Vx, Vy
        /// Set Vx = Vy - Vx, set VF = NOT borrow.
        /// If Vy > Vx, then VF is set to 1, otherwise 0. Then Vx is subtracted from Vy, and the results stored in Vx.
        /// </summary>
        void SubstractRegistersReverse(IMachineState machineState);

        /// <summary>
        /// 8xyE - SHL Vx {, Vy}
        /// Set Vx = Vx SHL 1.
        /// If the most-significant bit of Vx is 1, then VF is set to 1, otherwise to 0. Then Vx is multiplied by 2.
        /// </summary>
        void ShiftRegisterLeft(IMachineState machineState);

        /// <summary>
        /// 9xy0 - SNE Vx, Vy
        /// Skip next instruction if Vx != Vy.
        /// The values of Vx and Vy are compared, and if they are not equal, the program counter is increased by 2.
        /// </summary>
        void SkipNextInstructionIfRegisterNotEqualsRegister(IMachineState machineState);

        /// <summary>
        /// Annn - LD I, addr
        /// Set I = nnn.
        /// The value of register I is set to nnn.
        /// </summary>
        void LoadIntoIndexRegister(IMachineState machineState);

        /// <summary>
        /// Bnnn - JP V0, addr
        /// Jump to location nnn + V0.
        /// The program counter is set to nnn plus the value of V0.
        /// </summary>
        void JumpToV0PlusImmediate(IMachineState machineState);

        /// <summary>
        /// Cxkk - RND Vx, byte
        /// Set Vx = random byte AND kk.
        /// The interpreter generates a random number from 0 to 255, which is then ANDed with the value kk. 
        /// The results are stored in Vx. See instruction 8xy2 for more information on AND.
        /// </summary>
        void LoadRandomIntoRegister(IMachineState machineState);

        /// <summary>
        /// Dxyn - DRW Vx, Vy, nibble
        /// Display n-byte sprite starting at machineState.Memory location I at (Vx, Vy), set VF = collision.
        /// The interpreter reads n bytes from machineState.Memory, starting at the address stored in I. 
        /// These bytes are then displayed as sprites on screen at coordinates (Vx, Vy). 
        /// Sprites are XORed onto the existing screen. 
        /// If this causes any pixels to be erased, VF is set to 1, otherwise it is set to 0. 
        /// If the sprite is positioned so part of it is outside the coordinates of the display, it wraps around to the opposite side of the screen. 
        /// See instruction 8xy3 for more information on XOR, and section 2.4, Display, for more information on the Chip-8 screen and sprites.
        /// </summary>
        void DrawSprite(IMachineState machineState);

        /// <summary>
        /// Ex9E - SKP Vx
        /// Skip next instruction if key with the value of Vx is pressed.
        /// Checks the keyboard, and if the key corresponding to the value of Vx is currently in the down position, 
        /// PC is increased by 2.
        /// </summary>
        void SkipNextInstructionIfRegisterEqualsKeyPressed(IMachineState machineState);

        /// <summary>
        /// ExA1 - SKNP Vx
        /// Skip next instruction if key with the value of Vx is not pressed.
        /// Checks the keyboard, and if the key corresponding to the value of Vx is currently in the up position, 
        /// PC is increased by 2.
        /// </summary>
        void SkipNextInstructionIfRegisterNotEqualsKeyPressed(IMachineState machineState);

        /// <summary>
        /// Fx07 - LD Vx, DT
        /// Set Vx = delay timer value.
        /// The value of DT is placed into Vx.
        /// </summary>
        void LoadTimerValueIntoRegister(IMachineState machineState);

        /// <summary>
        /// Fx0A - LD Vx, K
        /// Wait for a key press, store the value of the key in Vx.
        /// All execution stops until a key is pressed, then the value of that key is stored in Vx.
        /// </summary>
        void LoadKeyIntoRegister(IMachineState machineState);

        /// <summary>
        /// Fx15 - LD DT, Vx
        /// Set delay timer = Vx.
        /// DT is set equal to the value of Vx.
        /// </summary>
        void LoadRegisterIntoDelayTimer(IMachineState machineState);

        /// <summary>
        /// Fx18 - LD ST, Vx
        /// Set sound timer = Vx.
        /// ST is set equal to the value of Vx.
        /// </summary>
        void LoadRegisterIntoSoundTimer(IMachineState machineState);

        /// <summary>
        /// Fx1E - ADD I, Vx
        /// Set I = I + Vx.
        /// The values of I and Vx are added, and the results are stored in I.
        /// </summary>
        void AddRegisterToIndexRegister(IMachineState machineState);

        /// <summary>
        /// Fx29 - LD F, Vx
        /// Set I = location of sprite for digit Vx.
        /// The value of I is set to the location for the hexadecimal sprite corresponding to the value of Vx. 
        /// See section 2.4, Display, for more information on the Chip-8 hexadecimal font.
        /// </summary>
        void LoadFontSpriteLocationFromValueInRegister(IMachineState machineState);

        /// <summary>
        /// Fx33 - LD B, Vx
        /// Store BCD representation of Vx in machineState.Memory locations I, I+1, and I+2.
        /// The interpreter takes the decimal value of Vx, 
        /// and places the hundreds digit in machineState.Memory at location in I, 
        /// the tens digit at location I+1, 
        /// and the ones digit at location I+2.
        /// </summary>
        void LoadBcdRepresentationFromRegister(IMachineState machineState);

        /// <summary>
        /// Fx55 - LD [I], Vx
        /// Store registers V0 through Vx in machineState.Memory starting at location I.
        /// The interpreter copies the values of registers V0 through Vx into machineState.Memory, starting at the address in I.
        /// </summary>
        void LoadAllRegistersFromValueInRegister(IMachineState machineState);

        /// <summary>
        /// Fx65 - LD Vx, [I]
        /// Read registers V0 through Vx from machineState.Memory starting at location I.
        /// The interpreter reads values from machineState.Memory starting at location I into registers V0 through Vx.
        /// </summary>
        void LoadFromValueInRegisterIntoAllRegisters(IMachineState machineState);
    }
}