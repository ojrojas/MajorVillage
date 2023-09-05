export type TypeLoaders = 'ring' | 'leapfrog' | 'raceby' | 'waveform' | 'dotwave' | 'orbit';

export interface LoaderOptions {
    size: number;
    color: string;
    speed?: number;
    lineWeight?: number;
    type: TypeLoaders;
    open: boolean;
}

